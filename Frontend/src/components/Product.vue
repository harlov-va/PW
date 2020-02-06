<template>
	<div>
		<h1>{{ product.title }}</h1>
		<router-link :to="{name: 'products'}">Back to products</router-link>
		<hr>
		<div class="alert alert-success">
			{{ product.price }}
		</div>
		<button :disabled="isDisabled"
						@click="addToCart(product.id_product)"
						class="btn btn-primary"
						>
					{{ textButton }}
				</button>
	</div>
</template>

<script>
	import {mapActions} from 'vuex';
	import {mapGetters} from 'vuex';
	export default {
		data(){
			return{
				textButton:'Add to cart'
			}
		},
		computed: {
			id(){
				return this.$route.params.id;
			},
			product(){
				return this.$store.getters['products/item'](this.id);
			},
			...mapGetters('cart', {
				inCart: 'products'
			}),
			isDisabled(){
				if (this.inCart.indexOf(this.product.id_product) === -1){
					this.textButton = 'Add to cart';
					return false;
				}
				else {
					this.textButton = 'A product in cart';
					return true;
				}
			}
		},
		methods: {
			...mapActions('cart', {
				addToCart: 'add',
				removeFromCart: 'remove'
			})
		}
	}
</script>