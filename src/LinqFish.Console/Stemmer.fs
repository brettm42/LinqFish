namespace LinqFish

[<AutoOpen>]
module Stemmer =
    open System.Globalization
    open System.Text.RegularExpressions
    
    let public Postfixes = 
        seq [ "es"; "ed"; "ing"; "en"; "ness"; "ly"; "able"; "tion"; "s"; ]
        
    let public Prefixes = 
        seq [ "pre"; "un"; "non"; "anti"; ]

//    let isAffix s =
//        Affixes |> Seq.iter(
//            if (Regex.IsMatch(s, m)) then Regex.Replace(s, m, String.Empty)
//            else String.Empty)

    let public GetStem(v:string, n) =
        let length = String.length(v) - 1
        for c = 0 to length do
            let prefix = Seq.tryFind (fun sl -> sl = v.[0..c]) Prefixes
            let postfix = Seq.tryFind (fun sl -> sl = v.[c..length]) Postfixes
            if prefix.IsSome then
                printfn "Found prefix in %s! %s" v (prefix.Value.ToString())
            if postfix.IsSome then
                printfn "Found postfix in %s! %s" v (postfix.Value.ToString())
                
    let Locale = CultureInfo.GetCultureInfo("en-US")