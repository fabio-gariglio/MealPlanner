import React, { Component } from 'react';
import { RecipeListItem } from './RecipeListItem';

export class RecipeList extends Component {

  constructor(props) {
    super(props);
    this.state = { recipes: [] };
    }

    componentDidMount() {
        this.populateRecipesData();
    }

  async populateRecipesData() {
     const response = await fetch('api/recipes');
     const data = await response.json();
     this.setState({ recipes: data });
  }

  render() {
    return (
      <div>
            {this.state.recipes.map(r => (<RecipeListItem {...r}/>))}
      </div>
    );
  }
}
