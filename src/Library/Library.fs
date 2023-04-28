namespace Library

module Test =
  let hello name = printfn "Hello %s" name

  type Endpoint =
    | Inclusive of int
    | Exclusive of int
    member x.ToInt =
      match x with
      | Inclusive n -> n
      | Exclusive n -> n

  type Interval = { From: Endpoint; To: Endpoint }

  [<CompiledName("IntervalToString")>]
  let intervalToString i =
    match i.From, i.To with
    | Inclusive x, Inclusive y -> sprintf "[%d, %d]" x y
    | Inclusive x, Exclusive y -> sprintf "[%d, %d)" x y
    | Exclusive x, Inclusive y -> sprintf "(%d, %d]" x y
    | Exclusive x, Exclusive y -> sprintf "(%d, %d)" x y

  type Maybe<'a> =
    | Nothing
    | Just of 'a
    member x.FromMaybe def =
      match x with
      | Nothing -> def
      | Just x -> x

  let fromMaybe def mb =
    match mb with
    | Nothing -> def
    | Just x -> x

  let maybe def f mb =
    match mb with
    | Nothing -> def
    | Just x -> f x
