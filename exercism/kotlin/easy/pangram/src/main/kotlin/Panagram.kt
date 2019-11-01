package Pangram

fun isPangram(str: String): Boolean =
    ('a'..'z').all { str.toLowerCase().contains(it) }