namespace LinqFish

[<AutoOpen>]
module Chunker =
    open System
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    let Space = " "

    let StringPrep str sep =
        ("^" + (sep : string) + (str : string).Trim() + sep + "$")
            .Split(sep.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
    
    let public GetBigrams args =
        let arr = StringPrep args Space
        let len = arr.Length - 2
        [| for a in 0 .. len do
            yield arr.[a], arr.[a + 1] |]
                                                 
    let public GetBigramsSep args sep =
        let arr = StringPrep args sep
        let len = arr.Length - 2
        [| for a in 0 .. len do
            yield arr.[a], arr.[a + 1] |]

    let public GetTrigrams args =
        let arr = StringPrep args Space
        let len = arr.Length - 2
        [| for a in 1 .. len do 
            yield arr.[a - 1], arr.[a], arr.[a + 1] |]

    let public GetTrigramsSep args sep =
        let arr = StringPrep args sep
        let len = arr.Length - 2
        [| for a in 1 .. len do 
            yield arr.[a - 1], arr.[a], arr.[a + 1] |]

    let public GetNGram args size =
        let arr = StringPrep args Space
        let len = arr.Length - 2
        [| for a in 0 .. size .. len do 
            yield arr.[a..size] |]

    let public SelectSeq grams =
        seq { for gram in grams do
                if gram.ToString().Contains("select") then
                    yield gram }

    let public Select(t, p) =
        match t with
        | "select" -> printfn "Select! Action: %s" p
        | "filter" -> printfn "Filter! Action: %s" p
        | "where" -> printfn "Where! Action: %s" p
        | "take" -> printfn "Take! Action: %s" p
        | _ -> printfn "null"

    let Locale = CultureInfo.GetCultureInfo("en-US")
