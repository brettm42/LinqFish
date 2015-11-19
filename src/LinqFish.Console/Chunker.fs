namespace LinqFish

[<AutoOpen>]
module Chunker =
    open System
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions
    
    let public GetBigrams (args : string) =
        let arr =("^" + args + "$").Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        let len = arr.Length - 1
        [| for a in 0 .. 1 .. len do
            match a with
            | len -> yield (arr.[a], "")
            | _ -> yield (arr.[a], arr.[a + 1]) |]
                                                 
    let public GetBigramsSep (args : string, separator : char) =
        let arr =("^" + args + "$").Split(separator)
        let len = arr.Length - 1
        [| for a in 0 .. 1 .. len do
            match a with
            | len -> yield (arr.[a], "")
            | _ -> yield (arr.[a], arr.[a + 1]) |]

    let public GetTrigrams(args : string) =
        let arr = ("^ " + args + " $").Split(' ')
        let len = arr.Length - 2
        [| for a in 0 .. 2 .. len do 
            match a with
            | 0 -> yield ("", arr.[a], arr.[a + 1])
            | len -> yield (arr.[a - 1], arr.[a], "")
            | _ -> yield (arr.[a - 1], arr.[a], arr.[a + 1]) |]

    let public GetTrigramsSep(args : string, separator : char) =
        let arr = ("^ " + args + " $").Split(separator)
        let len = arr.Length - 2
        [| for a in 0 .. 2 .. len do 
            match a with
            | 0 -> yield ("", arr.[a], arr.[a + 1])
            | len -> yield (arr.[a - 1], arr.[a], "")
            | _ -> yield (arr.[a - 1], arr.[a], arr.[a + 1]) |]

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
