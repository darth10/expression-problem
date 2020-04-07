{-# LANGUAGE DeriveFunctor #-}
{-# LANGUAGE TypeOperators #-}

module Functors (const, (>+<), (>*<), eval, view) where

import Prelude (Double, Functor, String, fmap, otherwise, show, (+), (*), (<))
import Text.Printf (printf)

data Const e = Const Double deriving Functor
data Add e = Add e e deriving Functor

data ExprF f = In (f (ExprF f))

foldExpr :: Functor f => (f a -> a) -> ExprF f -> a
foldExpr f (In t) = f (fmap (foldExpr f) t)

data (f :+: g) e = Inl (f e) | Inr (g e) deriving Functor

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

-- example

-- type Expr = ExprF (Const :+: Add)

-- const :: Double -> Expr
-- const x = In (Inl (Const x))

-- infixl 6 >+<
-- (>+<) :: Expr -> Expr -> Expr
-- x >+< y = In (Inr (Add x y))

-- add operation

class Functor f => View f where
  viewF :: f String -> String

instance View Const where
  viewF (Const x) = show x

instance View Add where
  viewF (Add x y) = printf "(%s + %s)" x y

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

infixr 7 :+:
type Expr = ExprF (Const :+: Add :+: Mult)

const :: Double -> Expr
const x = In (Inl (Const x))

infixl 6 >+<
(>+<) :: Expr -> Expr -> Expr
x >+< y = In (Inr (Inl (Add x y)))

infixl 7 >*<
(>*<) :: Expr -> Expr -> Expr
x >*< y = In (Inr (Inr (Mult x y)))

x1 = const 7
x2 = const 3
x3 = const 2

-- > let const2 x = In (Inl (Const x))
-- > :t const2
-- const2 :: Double -> ExprF (Const :+: g)
-- > let x1 = const2 7
-- > eval x1
-- <interactive>:...: error:
--     * Ambiguous type variable 'g0' arising from a use of 'eval'
--       prevents the constraint '(Eval g0)' from being solved.
--       Probable fix: use a type annotation to specify what 'g0' should be.

getAlgebra x
  | x < 10    = const 2.0
  | otherwise = const 4 >*< const 5 >+< const 6

-- :t getAlgebra
-- getAlgebra
--   :: (Ord a, Num a) =>
--      a -> ExprF (Const :+: (Add :+: Mult))
