namespace LinqFish

module Stemmer =
    open System
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    type public Stemmer =

        static member public Affixes = 
            [| "es", "ed", "ing", "en", "ness", "ly", "able", "tion" |]

        static member public GetStem(v, n) =
            match v with
            | Affixes -> printfn "found an affix! %s" v
            | _ -> printfn "null"
                
        member this.Locale = "en-US"