module FunctorsTests
  (tests) where

import Test.HUnit

foo x = (1, x)

test1 = TestCase (assertEqual "for (foo 3)," (1, 3) (foo 3))

tests = TestList [TestLabel "test1" test1]
