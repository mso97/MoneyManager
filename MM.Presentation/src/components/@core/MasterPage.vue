<template>
    <div>
        <div class="MasterPage"/>
        <router-view></router-view>
    </div>
</template>

<script>

    export default {
        name: 'Home',

        beforeCreate() {
            let token = localStorage.getItem('NossoDinheiroTK');

            if (token == null)
                this.$router.push('login')
            else
                this.$router.push('home')
        }
    }
</script>

<style scoped>
</style>