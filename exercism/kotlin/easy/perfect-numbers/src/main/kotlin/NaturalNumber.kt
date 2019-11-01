enum class Classification {
    DEFICIENT, PERFECT, ABUNDANT
}

fun classify(naturalNumber: Int): Classification {
    require(naturalNumber > 0) { "$naturalNumber must be natural" }
    val factorsSum = (1..naturalNumber / 2)
        .filter { naturalNumber.rem(it) == 0 }
        .sum()
    return when {
        factorsSum == naturalNumber -> Classification.PERFECT
        factorsSum > naturalNumber -> Classification.ABUNDANT
        else -> Classification.DEFICIENT
    }
}