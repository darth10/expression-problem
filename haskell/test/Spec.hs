import qualified FunctorsTests
import qualified TypeclassesTests
import Test.HUnit

main :: IO Counts
main =
  runTestTT $ TestList [
    FunctorsTests.tests
  , TypeclassesTests.tests
  ]
