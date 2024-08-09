
## Pillow library 

[Python Imaging Library (PIL)](http://www.pythonware.com/products/pil/http://) es una librería gratuita que permite la edición de imágenes directamente desde Python. Soporta una variedad de formatos, incluídos los más utilizados como GIF, JPEG y PNG. Una gran parte del código está escrito en C, por cuestiones de rendimiento.

Debido a que la librería soporta únicamente hasta la versión 2.7 de Python y, al parecer, no pretende avanzar con el desarrollo, Alex Clark y en colaboración con otros programadores ha desarrollado [Pillow](http://pillow.readthedocs.org/en/latest/), una bifuración más «amigable», según el autor, de PIL que pretende mantener una librería estable y que se adapte a las nuevas teconologías (Python 3.x). Por esta razón, recomiendo siempre preferir Pillow en lugar de PIL.

De todas maneras, independientemende de la librería que se desee utilizar, su implementación para los usuarios se mantiene casi idéntica.


## How to import


```PYTHON
!pip install Pillow==9.5.0
```


## Usage example


```PYTHON
from PIL import Image, ImageChops, ImageEnhance, ImageOps

def main():
image = Image.open("image.jpg")
# Invertir colores.
new_image = ImageChops.invert(image)
new_image.save("image_1.jpg")

# Escala de grises.
new_image = ImageOps.grayscale(image)
new_image.save("image_2.jpg")

# Resaltar luces.
new_image = ImageEnhance.Brightness(image).enhance(2)
new_image.save("image_3.jpg")

# Contraste.
new_image = ImageEnhance.Contrast(image).enhance(4)
new_image.save("image_4.jpg")

# Espejo.
new_image = ImageOps.mirror(image)
new_image.save("image_5.jpg")

# Cambiar tamaño.
new_image = image.resize((320, 240))
new_image.save("image_6.jpg")

# Diminuir nitidez.
new_image = ImageEnhance.Sharpness(image).enhance(-4)
new_image.save("image_7.jpg")

if __name__ == "__main__":
main()
```