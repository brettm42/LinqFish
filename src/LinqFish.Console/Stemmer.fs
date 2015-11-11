namespace LinqFish

[<AutoOpen>]
module Stemmer =
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions
    
    let public Affixes = 
        [| "es", "ed", "ing", "en", "ness", "ly", "able", "tion" |]

//    let isAffix s =
//        Affixes |> Seq.iter(
//            if (Regex.IsMatch(s, m)) then Regex.Replace(s, m, String.Empty)
//            else String.Empty)

    let public GetStem(v, n) =
        match v with
        | Affixes -> printfn "found an affix! %s" v
        | _ -> printfn "null"
                
    let Locale = CultureInfo.GetCultureInfo("en-US")