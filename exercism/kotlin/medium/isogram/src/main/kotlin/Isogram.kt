object Isogram {
    fun isIsogram(word: String) : Boolean =
        word
            .toLowerCase()
            .filter { it.isLetter() }
            .groupBy { it }
            .values
            .all { it.size == 1 }
}