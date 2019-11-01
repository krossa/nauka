class SpaceAge(private val seconds: Long) {

    fun onEarth() : Double = age(1.toDouble())
    fun onJupiter() : Double = age(11.862615)
    fun onMars() : Double = age(1.8808158)
    fun onMercury() : Double = age(0.2408467)
    fun onNeptune() : Double = age(164.79132)
    fun onSaturn() : Double = age(29.447498)
    fun onUranus() : Double = age(84.016846)
    fun onVenus() : Double = age(0.61519726)

    private fun age(orbital_period: Double) =
        "%.2f".format(seconds / orbital_period / 31557600).toDouble()        
}