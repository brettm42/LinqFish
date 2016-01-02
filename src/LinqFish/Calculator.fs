namespace LinqFish

[<AutoOpen>]
module Calculator =
    open System.Collections.Generic
    open System.Globalization
    open System.Text
    
    let Count (dict:Dictionary<string, int>) word count =
        if dict.ContainsKey(word) 
........... then dict.[word] <- count dict.[word]
        else dict.[word] <- count 0

    let public GetInstanceDistribution ngrams =
        let wordsA = ngrams |> Seq.map (fun (a, b) -> (a:string).ToLower())
        let wordsB = ngrams |> Seq.map (fun (a, b) -> (b:string).ToLower())
        let counts = new Dictionary<string, int>()
        wordsA |> Seq.iter (fun word -> Count counts word ((+) 1))
        wordsB |> Seq.iter (fun word -> Count counts word ((+) 1))
        counts

    let public GetWordCounts ngrams = 
        let words = ngrams |> Seq.map (fun (a, b) -> (a:string).ToLower())
        let counts = new Dictionary<string, int>()
        words |> Seq.iter (fun word -> Count counts word ((+) 1))
        counts
        
    let Locale = CultureInfo.GetCultureInfo("en-US")
