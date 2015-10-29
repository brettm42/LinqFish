namespace LinqFish

module Lemmatizer =
    open System
    open System.Globalization;
    open System.Text
    open System.Text.RegularExpressions;

    type public Lemmatizer(locale : CultureInfo) =

        static member public GetBigrams(args : string, separator : char) =
            let arr = args.Split(separator)
            [| for a in 0 .. 1 .. (arr.Length - 2) do
                yield (arr.[a], arr.[a + 1]) |]

        static member public GetTrigrams(args : string, separator : char) =
            let arr = args.Split(separator)
            [| for a in 0 .. 2 .. (arr.Length - 3) do 
                yield (arr.[a], arr.[a + 1], arr.[a + 2]) |]



        member this.Locale = locale
