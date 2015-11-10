namespace LinqFish

module Lemmatizer =
    open System
    open System.Globalization
    open System.Text
    open System.Text.RegularExpressions

    type public Lemmatizer =

        static member public GetLemma(v, n) =
            0

        member public this.Locale = "en-US"