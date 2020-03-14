
import FunctorsTests (tests)
import Test.HUnit

main :: IO Counts
main = runTestTT tests
