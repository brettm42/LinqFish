namespace LinqFish

[<AutoOpen>]
module Calculator =
    open System.Collections.Generic
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions
    
    let Count (dict:Dictionary<string, int>) word count =
        if dict.ContainsKey(word) then dict.[word] <- count dict.[word]
        else dict.[word] <- count 0

    let public GetDistribution ngrams =
        0

    let public GetWordCounts ngrams = 
        let words = ngrams |> Seq.map (fun (a, b) -> (a:string).ToLower())
        let counts = new Dictionary<string, int>()
        words |> Seq.iter (fun word -> Count counts word ((+) 1))
        counts
        
    let Locale = CultureInfo.GetCultureInfo("en-US")