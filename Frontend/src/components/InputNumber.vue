<template>
	<div class="form-group">
         <input type="number" 
			   min="0"
        	   class="form-control"
			   :value="value"
			   @input="onInput"
			   @keyup="$event.target.value=$event.target.value.replace(/[^\d]/,'')"				
        	   >
    </div>
</template>

<script>
	export default {
		props: ['value'],
		data(){
			return {
			}
		},
		computed: {

		},
		methods: {
			onInput(e){
				this.$emit('changedata', {
					value: e.target.value
				});
			}
		}
	}
</script>