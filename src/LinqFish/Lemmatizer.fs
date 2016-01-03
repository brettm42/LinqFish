namespace LinqFish

[<AutoOpen>]
module Lemmatizer =
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    let public Dictionary_enUS =
        seq [ "test"; "get"; "this";  ]

    let public GetLemma(v, n) =
        let length = String.length(v : string) - 1
        [| for c = 0 to length do
            let stem = Seq.tryFind (fun sl -> sl = v.[0..c]) Dictionary_enUS
            if stem.IsSome then 
                yield Regex.Replace(v, stem.Value.ToString(), "") |]

    let Locale = CultureInfo.GetCultureInfo("en-US")