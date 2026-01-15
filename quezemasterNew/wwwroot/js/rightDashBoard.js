// to shift elemensts to right by defaut based on width occupied by text
$jq('.right-sidebar').ready( () =>{
	
		const selectedClass = "highlightedtab"
	
		document.querySelectorAll(".right-sidebar span").forEach((ele) => {
			ele.parentElement.style.transform = `translateX(${ele.offsetWidth}px)`;
		});
		
		$jq('.right-sidebar > *:nth-child(1)').addClass(selectedClass)
		
		// assigning click event on all children of right sidebar container ie tabs
		$jq('.right-sidebar > *').click((e)=>{
		  // remove  class for  right sidebar tabs  
		  $jq('.right-sidebar > *').removeClass(selectedClass);
			
			console.log('clicked detected');
			
		  // add selected class in the parent element and current one. 
		  // parent element in case child element like icons and text is clicked
		  e.target.parentElement.classList.add(selectedClass);
		  e.target.classList.add(selectedClass);
		})
		
	}
)




