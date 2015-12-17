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
            if (str : string).Contains(sep) then
                let pre = str.Split(sep.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                if pre.Length >= 1 then
                    yield pre |]
            
    let Locale = CultureInfo.GetCultureInfo("en-US")
