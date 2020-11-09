import tensorflow as tf

print('start')



a = tf.Variable(1, name ='a')
b = tf.Variable(2, name ='b')
f = a + b
tf.print(f)

print('end')
