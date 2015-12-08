namespace LinqFish

[<AutoOpen>]
module Stemmer =
    open System.Globalization
    open System.Text.RegularExpressions
    
    let public Postfixes = 
        seq [ "es"; "ed"; "ing"; "en"; "ness"; "ly"; "able"; "esque"; "tion"; "'s"; "'ve";  ]
        
    let public Prefixes = 
        seq [ "pre"; "un"; "non"; "anti"; ]
        
    let public GetStem (v, n) =
        let length = String.length(v : string) - 1
        for c = 0 to length do
            let prefix = Seq.tryFind (fun sl -> sl = v.[0..c]) Prefixes
            let postfix = Seq.tryFind (fun sl -> sl = v.[c..length]) Postfixes
            if prefix.IsSome then
                printfn "Found prefix in %s! %s" v (prefix.Value.ToString())
            if postfix.IsSome then
                printfn "Found postfix in %s! %s" v (postfix.Value.ToString())
                
    let public GetStems (a, b) =
        let length = String.length(a : string) - 1
        [| for c = 0 to length do
            let prefix = Seq.tryFind (fun sl -> sl = a.[0..c]) Prefixes
            let postfix = Seq.tryFind (fun sl -> sl = a.[c..length]) Postfixes
            if prefix.IsSome then 
                yield Regex.Replace(a, prefix.Value.ToString(), "")
            else if postfix.IsSome then 
                yield Regex.Replace(a, postfix.Value.ToString(), "") |]

    let Locale = CultureInfo.GetCultureInfo("en-US")