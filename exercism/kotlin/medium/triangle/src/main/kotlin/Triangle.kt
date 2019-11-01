class Triangle(val a: Double, val b: Double, val c: Double) {
    constructor(a: Int, b: Int, c: Int) : this(a.toDouble(), b.toDouble(), c.toDouble())
    private val sides = listOf(a, b, c)
    init {
        require(sides.max()!! < (sides.sum() - sides.max()!!))
    }

    private val distinctSides = sides.distinct().size
    val isEquilateral : Boolean = distinctSides == 1
    val isIsosceles : Boolean = distinctSides <= 2
    val isScalene : Boolean = distinctSides == 3
}