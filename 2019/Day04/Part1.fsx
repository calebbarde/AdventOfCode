#load "Lib.fs"

open System
open Lib

let rec adjacentDigits (curChar : char) (code: char list) : bool =
    match code with
    | [] -> false
    | first::_ when (curChar = first) -> true
    | first::rest when first = curChar -> adjacentDigits first rest
    | first::rest -> adjacentDigits first rest 

let isValid (code: char list): bool =
    let first::rest = code
    (adjacentDigits first rest) && (successfulDigits code)

[271973..785961]
|> List.filter (Convert.ToString >> Seq.toList >> isValid)
|> List.length
|> printfn "there are %i valid combinations" 