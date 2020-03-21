module FunctorsTests
  (tests) where

import Functors
import Prelude ()
import Test.HUnit

c1 = const 7
c2 = const 2
c3 = const 3

addExpr1 = c1 >+< c2

multExpr1 = c1 >*< c2
multExpr2 = c2 >*< c3

addExpr2 = multExpr1 >+< multExpr2

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
