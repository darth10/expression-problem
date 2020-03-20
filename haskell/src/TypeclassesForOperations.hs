module TypeclassesForOperations
  () where

import Text.Printf (printf)

data Const   = Const Double
data Add x y = Add x y

class Expr e

instance Expr Const
instance (Expr x, Expr y) => Expr (Add x y)

class (Expr e) => Eval e where
  eval :: e -> Double

instance Eval Const where
  eval (Const x) = x

instance (Eval x, Eval y) => Eval (Add x y) where
  eval (Add x y) = eval x + eval y

-- add operation

class (Expr e) => View e where
  view :: e -> String

instance View Const where
  view (Const x) = show x

instance (View x, View y) => View (Add x y) where
  view (Add x y) = printf "(%s + %s)" (view x) (view y)

-- add type/variant

data Mult x y = Mult x y

instance (Expr x, Expr y) => Expr (Mult x y)

instance (Eval x, Eval y) => Eval (Mult x y) where
  eval (Mult x y) = eval x * eval y

instance (View x, View y) => View (Mult x y) where
  view (Mult x y) = printf "(%s * %s)" (view x) (view y)

-- getAlgebra x =
--   if x < 10 then Const 2
--   else Add (Const 4) (Const 5)

-- produces an error:
--
-- * Couldn't match expected type ‘Const’
--               with actual type ‘Add Const Const’
-- * In the expression: (Add (Const 4) (Const 5))

-- TODO examples/tests
