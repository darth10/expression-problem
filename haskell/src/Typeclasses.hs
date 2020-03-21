module Typeclasses
  () where

import Prelude (Double, String, show, (+), (*), ($))
import Text.Printf (printf)

class Expr t where
    const :: Double -> t
    add :: t -> t -> t

newtype Eval = Eval { eval :: Double }

instance Expr Eval where
    const   = Eval
    add x y = Eval $ eval x + eval y

e1 :: Expr t => t
e1 = add (const 1)
         (add (const 2)
              (const 3))

-- add operation

newtype View = View { view :: String }

instance Expr View where
    const n = View $ show n
    add x y = View $ printf "(%s + %s)" (view x) (view y)

-- add type/variant

class MultExpr t where
    mult :: t -> t -> t

instance MultExpr Eval where
    mult x y = Eval $ eval x * eval y

instance MultExpr View where
    mult x y = View $ printf "(%s * %s)" (view x) (view y)

e2 :: (Expr t, MultExpr t) => t
e2 = mult (const 2)
          (add (const 2)
               (const 3))

-- TODO tests
