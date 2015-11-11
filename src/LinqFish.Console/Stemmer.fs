namespace LinqFish

[<AutoOpen>]
module Stemmer =
    open System.Globalization
    open System.Text.RegularExpressions
    
    let public Postfixes = 
        seq [ "es"; "ed"; "ing"; "en"; "ness"; "ly"; "able"; "tion"; ]
        
    let public Prefixes = 
        seq [ "pre"; "un"; ]

//    let isAffix s =
//        Affixes |> Seq.iter(
//            if (Regex.IsMatch(s, m)) then Regex.Replace(s, m, String.Empty)
//            else String.Empty)

    let public GetStem(v:string, n) =
        let length = String.length(v) - 1
        // TODO take increasing slices of the ends and check: Array.tryFind (fun s -> s == slice) Affixes
        for c = 0 to length do
            let prefix = Seq.tryFind (fun sl -> sl = v.[0..c]) Prefixes
            let postfix = Seq.tryFind (fun sl -> sl = v.[c..length]) Postfixes
            if prefix.IsSome || postfix.IsSome then 
                if prefix.IsSome then
                    printfn "Found prefix in %s! %s" v (prefix.ToString())
                if postfix.IsSome then
                    printfn "Found postfix in %s! %s" v (postfix.ToString())
                
    let Locale = CultureInfo.GetCultureInfo("en-US")