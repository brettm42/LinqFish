namespace LinqFish

module Chunker =
    open System
    open System.Globalization;
    open System.Text
    open System.Text.RegularExpressions;

    type public Chunker(locale : CultureInfo, input : string) =

        static member public GetBigrams(args : string, separator : char) =
            let arr = args.Split(separator)
            [| for a in 0 .. 1 .. (arr.Length - 2) do
                yield (arr.[a], arr.[a + 1]) |]

        static member public GetTrigrams(args : string, separator : char) =
            let arr = args.Split(separator)
            [| for a in 0 .. 2 .. (arr.Length - 3) do 
                yield (arr.[a], arr.[a + 1], arr.[a + 2]) |]

        static member public SelectSeq(grams : Array) =
            seq { for gram in grams do
                  if gram.ToString().Contains("select") then
                      yield gram }
                      
        static member public Select(t1, t2) =
            match t1 with
            | "select" -> printfn "Select! Action: %s" t2
            | "test" -> printfn "Test! Action: %s" t2
            | "filter" -> printfn "Filter! Action: %s" t2
            | _ -> printfn "null"

        member this.Locale = locale
