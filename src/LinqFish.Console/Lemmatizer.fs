namespace LinqFish

[<AutoOpen>]
module Lemmatizer =
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    let public GetLemma(v, n) =
        v

    let Locale = CultureInfo.GetCultureInfo("en-US")