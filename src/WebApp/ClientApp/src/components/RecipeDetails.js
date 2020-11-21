import React, { Component } from 'react';

export class RecipeDetails extends Component {

  constructor(props) {
      super(props);

      this.state = {
          recipe: {}
      };
    }

    componentDidMount() {

        this.fetchRecipeDetails();
    }

    async fetchRecipeDetails() {
        
        const id = '2';

        const response = await fetch(`api/recipes/${id}`);
        const data = await response.json();
        this.setState({ recipe: data });
    }

  render() {
      return (
          <h1>{this.state.recipe.name}</h1>
    );
  }
}
