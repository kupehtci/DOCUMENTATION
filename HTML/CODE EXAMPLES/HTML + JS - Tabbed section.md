#HTML #JS #CSS 


This is an example of how to make a tabbed section and switch between sections by clicking on the tabs above it. 

This can be programmed by defining this tabs and sections in html and with an indexed array in Javascript have them stored as an array and activate / deactivate them depending on the button pressed: 

```html

<style>
#tabbed-division {  
    /*border: 1px solid #ccc;*/  
    border-radius: 5px;  
    overflow: hidden;  
  
    margin: 2rem;  
    padding: 1rem;  
  
    justify-content: center;  
    text-align: center;  
}  
  
.tab-button {  
    color: white;  
    background-color: rgba(0,0,0,0);  
  
    border: 1px solid rgba(0,0,0,0);  
    border-radius: 3rem;  
  
    cursor: pointer;  
    display: inline-block;  
  
    font-size: 16px;  
  
    margin-bottom: 2rem;  
    padding: 12px 24px;  
    text-align: center;  
    user-select: none;  
    vertical-align: top;  
  
    width: 20%;  
  
    transition-duration: 0.2s;  
}  
  
.tab-button:hover {  
    background-color: #575757;  
}  
  
.tab-button:focus,  
.tab-button:active {  
    outline: none;  
    border: 1px solid white;  
  
}  
  
.tab-button.active {  
    background-color: #444444;  
}  
  
.tab-content-item {  
    display: none;  
}  
  
.tab-content-item.active {  
    display: block;  
}
</style>

<!-- This is the tabbed section -->

<div id="tabbed-division">
	<button class="tab-button" data-tab-target="tab-1">Tab 1</button>
	<button class="tab-button" data-tab-target="tab-2">Tab 2</button>
	<button class="tab-button" data-tab-target="tab-3">Tab 3</button>

	<div id="tab-content">
		<div class="tab-content-item" id="tab-1">
			<h2>Tab 1 Content</h2>
			<p>This is the content for Tab 1.</p>
		</div>
		<div class="tab-content-item" id="tab-2">
			<h2>Tab 2 Content</h2>
			<p>This is the content for Tab 2.</p>
		</div>
		<div class="tab-content-item" id="tab-3">
			<h2>Tab 3 Content</h2>
			<p>This is the content for Tab 3.</p>
		</div>
	</div>
</div>

<!-- End of the structure of tabbed section -->

<script>
	document.addEventListener('DOMContentLoaded', function() {
		const tabButtons = document.querySelectorAll('.tab-button');
		const tabContentItems = document.querySelectorAll('.tab-content-item');

		tabButtons.forEach((button, index) => {
			button.addEventListener('click', () => {

				// Deselect all tabs and active the clicked one
				tabButtons.forEach(button => button.classList.remove('active'));
				tabContentItems.forEach(item => item.classList.remove('active'));

				button.classList.add('active');
				tabContentItems[index].classList.add('active');
			});
		});

		// Begin with first selected
		tabButtons[0].classList.add('active');
		tabContentItems[0].classList.add('active');

	});
</script>

```