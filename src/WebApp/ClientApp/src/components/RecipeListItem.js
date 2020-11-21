import React, { Component } from 'react';

export class RecipeListItem extends Component {

    render() {
        return (
            <a href={`/recipes/${this.props.id}`}>{this.props.name}</a>
        );
    }
}
