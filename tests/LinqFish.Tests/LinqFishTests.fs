namespace LinqFish.Tests

[<AutoOpen>]
module LinqFishTests =
    open LinqFish
    open Microsoft.VisualStudio.TestTools.UnitTesting

    [<TestMethod>]
    let public GetClausesTest() = 
        let result = LinqFish.Clauser.GetClauses "testing string"

        Assert.AreEqual(1, result.[0].GetLength, "Clauser should've returned 1 clause")
