{-# LANGUAGE DeriveFunctor #-}
{-# LANGUAGE TypeOperators #-}

module Functors
  () where

import Text.Printf (printf)

data (f :+: g) e = Inl (f e) | Inr (g e)

data ExprF f = In (f (ExprF f))

data Const e = Const Double deriving Functor
data Add e = Add e e deriving Functor

instance (Functor f, Functor g) => Functor (f :+: g) where
  fmap f (Inl e1) = Inl (fmap f e1)
  fmap f (Inr e2) = Inr (fmap f e2)

foldExpr :: Functor f => (f a -> a) -> ExprF f -> a
foldExpr f (In t) = f (fmap (foldExpr f) t)

class Functor f => Eval f where
  evalF :: f Double -> Double

instance Eval Const where
  evalF (Const x) = x

instance Eval Add where
  evalF (Add x y) = x + y

instance (Eval f, Eval g) => Eval (f :+: g) where
  evalF (Inl x) = evalF x
  evalF (Inr y) = evalF y

eval :: Eval f => ExprF f -> Double
eval expr = foldExpr evalF expr


-- add operation

class Functor f => View f where
  viewF :: f String -> String

instance View Const where
  viewF (Const x) = show x

instance View Add where
  viewF (Add x y) =  printf "(%s + %s)" x y

instance (View f, View g) => View (f :+: g) where
  viewF (Inl x) = viewF x
  viewF (Inr y) = viewF y

view :: View f => ExprF f -> String
view expr = foldExpr viewF expr

-- add type/variant

data Mult e = Mult e e deriving Functor

instance Eval Mult where
  evalF (Mult x y) = x * y

instance View Mult where
  viewF (Mult x y) = printf "(%s * %s)" x y

-- helper functions

-- lit :: Double -> ExprF (Const :+: g)
lit x = In (Inl (Const x))


infixl 6 >+<
-- (>+<) :: ExprF (f :+: (Add :+: g)) ->
--          ExprF (f :+: (Add :+: g)) ->
--          ExprF (f :+: (Add :+: g))
x >+< y = In (Inr (Inl (Add x y)))


infixl 7 >*<
-- (>*<) :: ExprF (f :+: (g :+: Mult)) ->
--          ExprF (f :+: (g :+: Mult)) ->
--          ExprF (f :+: (g :+: Mult))
x >*< y = In (Inr (Inr (Mult x y)))

x1 = lit 7
x2 = lit 3
x3 = lit 2

-- eval $ (x1 >+< x2) >*< x3       => 20.0
-- eval $ x1 >*< x3 >+< x2 >*< x3  => 20.0
-- eval $ x1 >+< x2 >*< x3         => 13.0
-- eval $ x1 >*< x2 >+< x3         => 23.0

-- TODO view examples

getAlgebra x =
  if x < 4 then lit 2.0
  else lit 4 >*< lit 5 >+< lit 6

-- :t getAlgebra
-- getAlgebra
--   :: (Ord a, Num a) =>
--      a -> ExprF (Const :+: (Add :+: Mult))
