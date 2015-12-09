namespace LinqFish

[<AutoOpen>]
module Clauser =
    open System
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    let public Punctuation = 
        seq [ ";"; "!"; "?"; "."; ]

    let public GetClauses str =
        [| for sep in Punctuation do
            let pre = (str : string).Split(sep.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            if pre.Length > 1 then
                yield pre |]
            
    let Locale = CultureInfo.GetCultureInfo("en-US")
