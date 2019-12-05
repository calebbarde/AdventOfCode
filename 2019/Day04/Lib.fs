module Lib

let rec successfulDigits (code : char list) : bool =
    (List.sort code) = code