namespace LinqFish

module Lemmatizer =
    open System
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    type public Lemmatizer(locale : CultureInfo) =

        static member public GetLemma(v, n) =
            0

        member this.Locale = locale
