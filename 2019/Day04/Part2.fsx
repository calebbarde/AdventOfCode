#load "Lib.fs"

open System
open Lib

let rec adjacentDigits (count : int) (curChar : char) (code: char list) : bool =
    match code with
    | [] -> count = 2
    | first::_ when (count = 2) && (curChar <> first) -> true
    | first::rest when first = curChar -> adjacentDigits (count + 1) first rest
    | first::rest -> adjacentDigits 1 first rest 

let isValid (code: char list): bool =
    let first::rest = code
    (adjacentDigits 1 first rest) && (successfulDigits code)

[271973..785961]
|> List.filter (Convert.ToString >> Seq.toList >> isValid)
|> List.length
|> printfn "there are %i valid combinations" 