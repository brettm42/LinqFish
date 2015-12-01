namespace LinqFish

[<AutoOpen>]
module Chunker =
    open System
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions
    
    let public GetBigrams (args : string) =
        let arr = ("^ " + args.Trim() + " $").Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        let len = arr.Length - 2
        [| for a in 0 .. len do
            yield (arr.[a], arr.[a + 1]) |]
                                                 
    let public GetBigramsSep (args : string, separator : char) =
        let arr = ("^" + separator.ToString() + args + separator.ToString() + "$").Split(separator)
        let len = arr.Length - 2
        [| for a in 0 .. len do
            yield (arr.[a], arr.[a + 1]) |]

    let public GetTrigrams(args : string) =
        let arr = ("^ " + args + " $").Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        let len = arr.Length - 2
        [| for a in 1 .. len do 
            yield (arr.[a - 1], arr.[a], arr.[a + 1]) |]

    let public GetTrigramsSep(args : string, separator : char) =
        let arr = ("^" + separator.ToString() + args + separator.ToString() + "$").Split(separator)
        let len = arr.Length - 2
        [| for a in 1 .. len do 
            yield (arr.[a - 1], arr.[a], arr.[a + 1]) |]

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
