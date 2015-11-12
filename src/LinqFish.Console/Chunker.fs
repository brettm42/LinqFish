namespace LinqFish

[<AutoOpen>]
module Chunker =
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    let public GetTrigrams(args : string, separator : char) =
        let arr = args.Split(separator)
        [| for a in 0 .. 2 .. (arr.Length - 3) do 
            yield (arr.[a], arr.[a + 1], arr.[a + 2]) |]

    let public SelectSeq grams =
        seq { for gram in grams do
                if gram.ToString().Contains("select") then
                    yield gram }
                          
    let public GetBigramsSep (args : string, separator : char) =
        let arr = args.Split(separator)
        [| for a in 0 .. 1 .. (arr.Length - 2) do
            yield (arr.[a], arr.[a + 1]) |]

    let public GetBigrams (args : string) =
        let arr = args.Split(' ')
        [| for a in 0 .. 1 .. (arr.Length - 2) do
            if a = 0 then yield ("", arr.[a + 1])
            else if a = arr.Length - 2 then yield (arr.[a], "")
            else yield (arr.[a], arr.[a + 1]) |]

    let public Select(t, p) =
        match t with
        | "select" -> printfn "Select! Action: %s" p
        | "filter" -> printfn "Filter! Action: %s" p
        | "where" -> printfn "Where! Action: %s" p
        | "take" -> printfn "Take! Action: %s" p
        | _ -> printfn "null"

    let Locale = CultureInfo.GetCultureInfo("en-US")
