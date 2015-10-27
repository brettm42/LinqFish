namespace LinqFish

module Chunker =
    open System
    open System.Globalization;
    open System.Text

    //type public Chunker(locale : CultureInfo, input : string) =
    type public Chunker =

        static member public GetBigrams(args : string) =
            [| args.Split(' ') |]
            |> Seq.skip 1
            |> Seq.take 2
            |> Seq.toList

//            [ for word in [| args.Split(' ') |] do
//                
//                yield () ]
//                
//        static member Bigrams (args : string) =
//            let arr = [| args.Split(' ') |]
//            
//
//
//           [ for word in [| args.Split(' ') |] do
//               
//               yield (word, Array.in  .IndexOf(word)) ]
                              
        //member this.Locale = locale

        