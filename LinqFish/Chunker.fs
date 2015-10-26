namespace LinqFish

    module Chunker =
        open System
        open System.Text

        type Chunker(locale : string) =

            let bigrams (args : string) =
                args.Split(' ')

            member this.Locale = locale