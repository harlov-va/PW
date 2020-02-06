<template>
	<div >
        <label>{{ title }}</label>
		<hr>
		
		<p v-for="(item, index) in  answers">
			<input name="radio" type="radio" :value="item" key='index'
			:checked="index === 0"
			@click="onClickRadio(index)"
			> 
			{{ item }}
		</p>
		<hr>
    </div>
</template>

<script>
	export default {
		props: ['title', 'answers'],
		data(){
			return {
			}
		},
		computed: {

		},
		methods: {
			onClickRadio(i){
				this.$emit('chousevariant',i);
			}
		}
	}
</script>