#JS 

The scroll position that user keeps in the page can be modified. 
This position is a 2D vector that can be seted by: 

```JS
window.scrollTo(xCoord, yCoord);
```

If you want to scroll to the top of the window page, need to be in (0, 0) position to scroll up to top left corner. 

Parameters

- `xCoord` is the pixel along the horizontal axis.
- `yCoord` is the pixel along the vertical axis.


## SMOOTH

Can also be done with a smooth animation: 

```JS
$("a[href='#top']").click(function() {
  $("html, body").animate({ scrollTop: 0 }, "slow");
  return false;
});
```