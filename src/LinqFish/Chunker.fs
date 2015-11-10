﻿namespace LinqFish

module Chunker =
    open System
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    type public Chunker =
        
        static member public GetTrigrams(args : string, separator : char) =
            let arr = args.Split(separator)
            [| for a in 0 .. 2 .. (arr.Length - 3) do 
                yield (arr.[a], arr.[a + 1], arr.[a + 2]) |]

        static member public SelectSeq(grams : Array) =
            seq { for gram in grams do
                  if gram.ToString().Contains("select") then
                      yield gram }
                          
        static member public GetBigramsSep (args : string, separator : char) =
            let arr = args.Split(separator)
            [| for a in 0 .. 1 .. (arr.Length - 2) do
                yield (arr.[a], arr.[a + 1]) |]

        static member public GetBigrams (args : string) =
            let arr = args.Split(' ')
            [| for a in 0 .. 1 .. (arr.Length - 2) do
                yield (arr.[a], arr.[a + 1]) |]

        static member public Select(t, p) =
            match t with
            | "select" -> printfn "Select! Action: %s" p
            | "filter" -> printfn "Filter! Action: %s" p
            | "where" -> printfn "Where! Action: %s" p
            | "take" -> printfn "Take! Action: %s" p
            | _ -> printfn "null"        

        member this.Locale = "en-US"
