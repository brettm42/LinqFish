namespace LinqFish

module Lemmatizer =
    open System
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    let public GetLemma(v, n) =
        v

    let Locale = Globalization.CultureInfo.GetCultureInfo("en-US")