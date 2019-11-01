object Raindrops {
    fun convert(number: Int) : String {
        val result = mapOf( 3 to "Pling", 5 to "Plang", 7 to "Plong")
            .filter { number.rem(it.key) == 0 }
            .values.joinToString("")
        return if (result.isEmpty()) number.toString() else result 
    }
 }