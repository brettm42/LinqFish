namespace LinqFish

[<AutoOpen>]
module Clauser =
    open System
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    let public Punctuation = 
        seq [ ";"; "." ]

    let public GetClauses str =
        if Punctuation in str then
            yield (str : string).Split(Punctuation, StringSplitOptions.RemoveEmptyEntries) 
        else 
            yield str
            
    let Locale = CultureInfo.GetCultureInfo("en-US")
