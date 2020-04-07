module TypeclassesTests
  (tests) where

import Typeclasses (Expr, MultExpr, const, add, mult, eval, view)
import Prelude ()
import Test.HUnit

c1, c2, c3 :: Expr t => t

c1 = const 7
c2 = const 2
c3 = const 3

addExpr1, multExpr1, multExpr2, addExpr2 :: (Expr t, MultExpr t) => t

addExpr1 = add c1 c2
multExpr1 = mult c1 c2
multExpr2 = mult c2 c3
addExpr2 = add multExpr1 multExpr2

tests =
  test [
    "eval const test"    ~: eval c1        ~=? 7,
    "eval add test"      ~: eval addExpr1  ~=? 9,
    "eval mult test"     ~: eval multExpr1 ~=? 14,
    "eval add mult test" ~: eval addExpr2  ~=? 20,

    "view const test"    ~: view c1        ~=? "7.0",
    "view add test"      ~: view addExpr1  ~=? "(7.0 + 2.0)",
    "view mult test"     ~: view multExpr1 ~=? "(7.0 * 2.0)",
    "view add mult test" ~: view addExpr2  ~=? "((7.0 * 2.0) + (2.0 * 3.0))"
  ]
