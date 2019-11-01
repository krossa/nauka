object BinarySearch {
    fun search(list: List<Int>, target: Int) : Int {
        var left = 0
        var right = list.lastIndex
        while (left <= right) {
            var middle_index = (left + right) / 2
            var middle_value = list[middle_index]
            when {
                middle_value == target -> return middle_index 
                middle_value < target -> left = middle_index + 1 
                else -> right = middle_index - 1
            }
        }
        return -1
    }
}